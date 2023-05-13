from __future__ import print_function

import io
import numpy as np
from imageio import imread, imsave
import tensorflow as tf

# import os
# os.environ["TF_FORCE_GPU_ALLOW_GROWTH"] = "true"

from model import encoder, decoder
#flags在全局中用于接收命令行传递参数
flags = tf.app.flags
flags.DEFINE_string('input', r'E:\pythonProjects\GraDesign\RNN\residual-rnn-master\imgs\0.png', 'input image path')
flags.DEFINE_integer('iters', 30, 'number of iterations')
flags.DEFINE_string('output', r'E:\pythonProjects\GraDesign\RNN\residual-rnn-master\compressed', 'output path')
flags.DEFINE_string('model', 'save/model', 'saved model')

FLAGS = flags.FLAGS

try:
    img = imread(FLAGS.input).astype(np.float32)
except:
    print('please check input image path')
    exit()
# print(img.shape)
# input()
# import cv2
# img=cv2.resize(img,(512,512))
# print(img.shape)
# input()
# cv2.imshow('1',img)
# cv2.waitKey(0)
height, width, channel = img.shape
new_height = height + 16 - height % 16
new_width = width + 16 - width % 16
img_padded = np.pad(img, ((0, new_height - height),
                          (0, new_width - width), (0, 0)), 'constant')
# print(img_padded.shape)
# input()
inputs = np.expand_dims(img_padded, axis=0)

# print(img)
# input()

batch_size = 1
pinputs = tf.placeholder(tf.float32, [batch_size, new_height, new_width, 3])
inputs_ = pinputs / 255.0 - 0.5
e = encoder(batch_size=batch_size, height=new_height, width=new_width)
d = decoder(batch_size=batch_size, height=new_height, width=new_width)

codes = []
for i in range(FLAGS.iters):
    code = e.encode(inputs_)
    codes.append(code)
    outputs = d.decode(code)
    inputs_ = inputs_ - outputs

saver = tf.train.Saver()
eval_codes = []
with tf.Session() as sess:
    saver.restore(sess, FLAGS.model)
    for i in range(FLAGS.iters):
        c = codes[i].eval(feed_dict={pinputs: inputs})
        print(len(eval_codes))
        eval_codes.append(c)
int_codes = (np.stack(eval_codes).astype(np.int8) + 1) // 2
export = np.packbits(int_codes.reshape(-1))

np.savez_compressed(FLAGS.output, s=int_codes.shape, o=(height, width), c=export)
