import rawpy
import cv2
import os
import numpy as np

def prepare(img_path, save_path):
    # path = r'E:\pythonProjects\GraDesign\RNN\residual-rnn-master\raw_images\puppy.DNG'
    for index, filename in enumerate(os.listdir(img_path)):
        print(index,filename)
        img = rawpy.imread(img_path + '/' + filename)
        # img = img.postprocess(use_camera_wb=True, half_size=True,
        #                       no_auto_bright=True, output_bps=8)
        img = img.postprocess(use_camera_wb=True, half_size=True, no_auto_bright=True, output_bps=8)
        para=float(pow(2,8))
        rgb = np.float32(img / para*255.0)
        rgb = np.asarray(rgb,np.uint8)


        # print(img.shape)
        cv2.imwrite(save_path + '/' + str(index) + '.png', img)
    # cv2.imwrite(r'E:\pythonProjects\GraDesign\RNN\residual-rnn-master\imgs/1.png',img)


if __name__ == '__main__':
    prepare(img_path=r'E:/pythonProjects/GraDesign/RNN/residual-rnn-master/raw_images/'
            , save_path=r'E:/pythonProjects/GraDesign/RNN/residual-rnn-master/imgs/')
