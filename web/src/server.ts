import axios from 'axios'
import * as model from './components/model'

if (process.env.NODE_ENV == 'production')
    axios.defaults.baseURL = 'https://navi.oldzeng.com'
else
    axios.defaults.baseURL = 'http://localhost:5002'

console.log(process.env.NODE_ENV)

axios.interceptors.response.use(res => {
    if (res.status === 200) {
        if (res.data)
            return Promise.resolve(res.data)
        return Promise.resolve(res)
    } else {
        if (res.data)
            alert(res.data)
        return Promise.reject(res.data)
    }
})

class Server {
    async addUser(user: model.User): Promise<boolean> {
        try {
            await axios.post('/api/user', user)
            return true
        }
        catch (err) {
            return false
        }
    }

    async data(route: string): Promise<Tab[]> {
        var data: LinkDto[] = await axios.get(`/api/data/${route}`)
        let res: Tab[] = []
        for (var item of data) {
            let index = res.findIndex(x => x.id == item.tabid)
            if (index < 0) {
                res.push({
                    id: item.tabid,
                    name: item.tabtitle,
                    links: item.id ? [<Link>item] : []
                })
            } else {
                res[index].links.push(<Link>item)
            }
        }
        return res
    }

    async changeLink(data: Link) {
        return await axios.patch('/api/link', data)
    }

    async addLink(tabid: number, data: Link) {
        if (!data.tabid)
            data.tabid = tabid
        return await axios.post(`/api/link`, data)
    }

    async deletelink(id: number): Promise<boolean> {
        let res = await axios.delete(`/api/link/${id}`)
        return res == null
    }

    async changeTab(tabname: string) {
        return await axios.patch(`/api/tab?tab=${tabname}`)
    }

    async addTab(tabname: string) {
        let tab = { title: tabname }
        try {
            await axios.post('/api/tab', tab)
            return true
        } catch{
            return false
        }
    }

    async auth(name: string, pwd: string): Promise<boolean> {
        try {

            let res: any = await axios.post('/api/auth', {
                username: name,
                password: pwd
            })
            if (res.access_token) {
                axios.defaults.headers.common['Authorization'] = `JWT ${res.access_token}`
                return true
            }
            return false;
        } catch (error) {
            return false
        }
    }
}
export default new Server();