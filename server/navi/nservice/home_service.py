from navi.models import *
from navi.utils import *
from itertools import  groupby

def get_links(userid):
    query = Tab.select(Link,Tab.title.alias('tabtitle'))\
        .join(Link)\
        .where(Tab.userid == userid)\
        .dicts()

    # data = groupby(query)
    return list(query)

def find_user(username):
    query = User.get((User.name == username) & (User.deletetime is not None))
    return query


def add_tab(tab: dict):
    tab['createtime'] = datetime.datetime.now()
    Tab.insert(tab).execute()


def delete_tab(tabid):
    Tab.update({Tab.deletetime : datetime.datetime.now()})\
        .where(Tab.id == tabid)\
        .execute()


def add_link(link):
    link['createtime'] = datetime.datetime.now()
    Link.insert(link).execute()


def delete_link(id):
    Link.update({Link.deletetime: datetime.datetime.now()}) \
        .where(Link.id == id) \
        .execute()