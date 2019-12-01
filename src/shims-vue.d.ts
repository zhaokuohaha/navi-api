declare module '*.vue' {
  import Vue from 'vue'
  export default Vue
}


declare class Tab {
  name: string
  links?: Link[]
}

declare class Link {
  title: string
  url: string
  icon?: string
}