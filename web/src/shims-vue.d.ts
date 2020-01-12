declare module '*.vue' {
  import Vue from 'vue'
  export default Vue
}


declare class Tab {
  id: number
  name: string
  links: Link[]
}

declare class Link {
  id: number
  tabid: number
  title: string
  url: string
  icon?: string
  bgcolor?: string
  createtime?: Date
  deletetime?: Date
}

declare class LinkDto {
  tabid: number
  tabtitle: string

  id: number
  title: string
  url: string
  icon?: string
  bgcolor?: string
  createtime: Date
  deletetime: Date
}