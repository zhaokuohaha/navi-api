import axios from 'axios'

if (process.env.NODE_ENV == 'production')
    axios.defaults.baseURL = 'https://navi.oldzeng.com'
else
    axios.defaults.baseURL = 'http://localhost:5002'

console.log(process.env.NODE_ENV)

axios.interceptors.response.use(res => {
    if (res.status === 200) {
        return Promise.resolve(res.data)
    } else {
        return Promise.reject(res.data)
    }
})

class Server {
    async data(route: string): Promise<Tab[]> {
        var data: LinkDto[] = await axios.get(`/api/data/${route}`)
        let res: Tab[] = []
        for (var item of data) {
            let index = res.findIndex(x => x.id == item.tabid)
            if (index < 0) {
                res.push({
                    id: item.tabid,
                    name: item.tabtitle,
                    links: [<Link>item]
                })
            } else {
                res[index].links.push(<Link>item)
            }
        }
        return res
    }

    async changeLink(data: Link, tabname: string, linkname: string) {
        return await axios.patch(`/api/link?link=${linkname}&tab=${tabname}`, data)
    }

    async addLink(tabname: string, data: Link) {
        return await axios.post(`/api/link?tab=${tabname}`, data)
    }

    async changeTab(tabname: string) {
        return await axios.patch(`/api/tab?tab=${tabname}`)
    }

    async addTab() {
        return await axios.post('/api/tab')
    }
}
export default new Server();