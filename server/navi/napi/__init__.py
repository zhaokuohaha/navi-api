from flask import Blueprint

napi = Blueprint('napi', __name__)

# TODO 这里的引用必须放在创建蓝图之后才可以, 放在签名就会造成循环引用, 不知道为什么. 不引用的化api没法监听到路由


def init_api():
    from . import home_controller


init_api()
