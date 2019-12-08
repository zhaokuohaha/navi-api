from . import napi
from navi.utils import json_resp
import navi.nservice.home_service as h_service


@napi.route('/api/data', methods=['GET'])
@napi.route('/api/data/<userid>', methods=['GET'])
def get_data(userid=None):
    if userid is None:
        return json_resp(status=400, errinfo='未实现')
    data = h_service.get_links(userid)
    return json_resp(data)


@napi.route('/')
def test():
    return 'Hello Word'
