import axios from 'axios'

axios.defaults.baseURL = 'https://navi.oldzeng.com/api'
// if (process.env.NODE_ENV == 'production')
// else
//     axios.defaults.baseURL = 'http://localhost:3000'

console.log(process.env.NODE_ENV)

axios.interceptors.response.use(res => {
    if (res.status === 200) {
        return Promise.resolve(res.data)
    } else {
        return Promise.reject(res.data)
    }
})

class Server {
    async data(): Promise<Tab[]> {
        return await axios.get('/data')
    }

    async changeLink(data: Link, tabname: string, linkname: string) {
        return await axios.patch(`/link?link=${linkname}&tab=${tabname}`, data)
    }

    async addLink(tabname: string, data: Link) {
        return await axios.post(`/link?tab=${tabname}`, data)
    }

    async changeTab(tabname: string) {
        return await axios.patch(`/tab?tab=${tabname}`)
    }

    async addTab() {
        return await axios.post('/tab')
    }
}
export default new Server();