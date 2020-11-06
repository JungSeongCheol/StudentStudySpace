import time
import picamera

# with picamera.PiCamera() as camera:
#     camera.resolution = (640, 480)
#     camera.start_preview()
#     camera.start_recording('foo.h264')
#     camera.wait_recording(60)
#     camera.stop_recording()
#     camera.stop_preview()

with picamera.PiCamera() as camera:
    camera.resolution = (1280, 720)
    camera.start_preview()
    camera.exposure_compensation = 2
    camera.exposure_mode = 'snow' # off, auto, night, snow, spotlight, sports, nightpreview, backlight ..
    camera.meter_mode = 'spot' # average, spot, backlist, matrix
    camera.image_effect = 'hatch' #none, negative, solarize, sketch, denoise, emboss, oilpaint, hatch ..
    # Give the camera some time to adjuist to conditions
    time.sleep(4)
    camera.exif_tags['IFD0.Artist'] = 'Kim'
    camera.exif_tags['IFD0.Copyright'] = 'Copyleft Kim'
    camera.capture('foo.jpg')
    camera.stop_preview()