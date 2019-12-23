from flask import Response, jsonify
import jsonpickle
import json
import datetime


def json_resp(jobj=None, status=200, errinfo=None):
    if status >= 200 and status < 300:
        jsonstr = jsonpickle.encode(jobj, unpicklable=False)
        # jsonstr = json.dumps(jobj, ensure_ascii=False,
        #                      default=datetime_handler)
        return Response(jsonstr, mimetype='application/json', status=status)
    else:
        return Response('{"errinfo":"%s"}' % (errinfo,), mimetype='application/json', status=status)


def obj_to_dict(obj, exclude=None):
    dict = obj.__dict__
    if exclude:
        for key in exclude:
            if key in dict:
                dict.pop(key)
    return dict


def query_to_list(query, exclude=None):
    list = []
    for obj in query:
        dict = obj_to_dict(obj, exclude)
        list.append(dict)
    return list


def datetime_handler(x):
    if isinstance(x, datetime.datetime):
        # return x.isoformat()
        return x.strftime("%Y-%m-%d %H:%M:%S")
