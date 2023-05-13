import matplotlib.pyplot as plt
import tensorflow as tf

# 读取图像数据
img1 = tf.gfile.FastGFile(r'E:\pythonProjects\实验结果图片\lenna_mine\lenna_HR.png', 'rb').read()
img2 = tf.gfile.FastGFile(r'E:\pythonProjects\实验结果图片\lenna_mine\lenna_fdjx8.png', 'rb').read()
# img3 = tf.gfile.FastGFile('compressed.jpg', 'rb').read()

with tf.Session() as sess:
    # 用ipeg格式将图像解码得到三维矩阵(png格式用decode_png)
    # 解码后得到结果为张量
    img_data1 = tf.image.decode_png(img1)
    img_data2 = tf.image.decode_png(img2)
    # img_data3 = tf.image.decode_jpeg(img3)
    # 打印出得到的三维矩阵
    # print(img_data.eval())
    # 使用pyplot可视化得到的图像
    # plt.imshow(img_data1.eval())
    # plt.show()
    # plt.imshow(img_data2.eval())
    # plt.show()
    # plt.imshow(img_data3.eval())
    # plt.show()
    # 转换格式
    # 转换图像的数据类型
    # img_data1 = tf.image.convert_image_dtype(img_data1, dtype=tf.uint8)
    # img_data2 = tf.image.convert_image_dtype(img_data2, dtype=tf.uint8)
    # 将图像的三维矩阵重新按照png格式存入文件
    # encoded_image = tf.image.encode_jpeg(img_data1)
    # 得到图像的png格式
    # with tf.gfile.GFile('E:/pythonProjects/residual-rnn-master/eval/compressed.jpg', 'wb') as f:
    #     f.write(encoded_image.eval())

# 返回峰值信噪比和结构相似度
im1 = tf.image.convert_image_dtype(img_data1, tf.float32)
im2 = tf.image.convert_image_dtype(img_data2, tf.float32)
# im3 = tf.image.convert_image_dtype(img_data3, tf.float32)
psnr12 = tf.image.psnr(im1, im2, max_val=255)
ssim12 = tf.image.ssim(im1, im2, max_val=255)
# msssim12=tf.image.ms
# psnr13 = tf.image.psnr(im1, im3, max_val=255)
# ssim13 = tf.image.ssim(im1, im3, max_val=255)
psnr12 = tf.reduce_mean(psnr12)
ssim12 = tf.reduce_mean(ssim12)
# psnr13 = tf.reduce_mean(psnr13)
# ssim13 = tf.reduce_mean(ssim13)
print(psnr12)
print(ssim12)
with tf.Session() as sess:
    psnr12 = psnr12.eval()
    ssim12 = ssim12.eval()
    # psnr13 = psnr13.eval()
    # ssim13 = ssim13.eval()
    print('PSNR12:', psnr12)
    print('SSIM12:', ssim12)
    # print('PSNR13:', psnr13)
    # print('SSIM13:', ssim13)
