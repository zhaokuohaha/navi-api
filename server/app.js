const Koa = require('koa');
const router = require('koa-router')();
var bodyparser = require('koa-bodyparser');
const cors = require('@koa/cors');
const app = new Koa();

const low = require('lowdb')
const FileSync = require('lowdb/adapters/FileSync')
const adapter = new FileSync('db.json')
const db = low(adapter)

app.use(cors());
app.use(bodyparser());

app.use(async (ctx, next) => {
    const rt = ctx.response.get('X-Response-Time');
    console.log(`${ctx.method} ${ctx.url} - ${rt}`);
    await next();
});

router.get('/data', async (ctx, next) => {
    data = db.getState();
    ctx.response.body = data;
});

router.patch('/link', async (ctx, next) => {
    ctx.body = '未实现'
})

router.post('/link', async (ctx, next) => {
    let tabname = ctx.request.query.tab
    let link = ctx.request.body;

    let tab = db.read().find({ 'name': tabname })
    if (tab.value() && tab.has('links')) {
        tab.get('links').push(link).write()
        ctx.body = tab
    } else {
        ctx.body = "找不到组: " + tabname
        ctx.status = 404
    }
})

router.patch('/tab/:tab', async (ctx, next) => {
    ctx.body = '未实现'
})

router.post('/tab', async (ctx, next) => {
    ctx.body = '未实现'
})

app.use(router.routes())
app.listen(3000);
console.log('app started at port 3000...');