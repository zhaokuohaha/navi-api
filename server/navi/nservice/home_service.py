from navi.models import *
from navi.utils import *


def get_links(userid):
    # a = ntab(id=1, userid=1, title='ddd')
    # b = ntab(id=2, userid=1, title='ddd')
    # return list([a, b])
    query = ntab.select()
    return query_to_list(query)
