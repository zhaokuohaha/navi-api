import io
from urllib.request import urlopen
from colorthief import ColorThief
from urllib.parse import urlparse
import tldextract
import socket

socket.setdefaulttimeout(60 * 2)


def get_main_color(image_url):
    try:
        fd = urlopen(image_url)
        f = io.BytesIO(fd.read())
        color_thief = ColorThief(f)
        fd.close()
        return 'rgb' + str(color_thief.get_color(quality=1))
    except Exception as ex:
        print(ex)
        return ''


def get_bgcolor(icon_url):
    bgcolor = get_main_color(icon_url)
    return bgcolor if bgcolor else '#FFFFFF'


def get_icon(url_path):
    url = urlparse(url_path)
    ext = tldextract.extract(url_path)
    icon_urls = [
        f'{url.scheme}://{url.netloc}/favicon.ico',
        f'{url.scheme}://{url.hostname}/favicon.ico',
        f'{url.scheme}://{ext.registered_domain}/favicon.ico',
        f'{url.scheme}://www.{ext.registered_domain}/favicon.ico'
    ]

    for icon_url in icon_urls:
        color = get_main_color(icon_url)
        if color != '':
            return icon_url, color
    return 'https://blog.oldzeng.com/upload/2020/1/favicon-4cf3d6ef2633485ba6395ad6db065b15.ico', '#FFFFFF'


if __name__ == '__main__':
    print(get_icon('https://oschina.net/jastme/blog/1936553'))