from . import napi
from navi.utils import json_resp


@napi.route('/api/data', methods=['GET'])
@napi.route('/api/data/<user>', methods=['GET'])
def get_data(user=None):
    if user is None:
        return json_resp(status=400, errinfo='未实现')
    return json_resp({'msg': f'ddd-${user}'})


@napi.route('/')
def test():
    return 'Hello Word'
