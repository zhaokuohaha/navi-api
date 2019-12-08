from flask import Blueprint

napi = Blueprint('napi', __name__)


def init_api():
    from . import home_controller


init_api()
