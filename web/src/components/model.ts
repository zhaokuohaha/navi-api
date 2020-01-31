export enum action {
    default,
    add,
    update,
    delete,
    cancel,
}

export class Link {
    id: number = -1
    tabid: number = -1
    title: string = ''
    url: string = ''
    icon?: string
    bgcolor?: string
    createtime?: Date
    deletetime?: Date
}

export class User {
    name = ''
    pwd = ''
}