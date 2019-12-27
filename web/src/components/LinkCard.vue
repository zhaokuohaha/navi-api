<template>
  <div class="link-card card" :style="customStyle" @click="openlink()">
    <img class="c-icon" :src="iconlink" alt srcset />
    <div class="c-title">{{linkinfo.title}}</div>
  </div>
</template>

<script lang="ts">
import { Prop, Vue, Component, Provide } from "vue-property-decorator";

@Component
export default class LinkCard extends Vue {
  @Prop() private linkinfo!: Link;

  get customStyle() {
    return {
      backgroundColor: this.linkinfo.bgcolor || "#fff"
    };
  }
  get iconlink() {
    return this.linkinfo.icon || "/favicon.ico";
  }

  openlink() {
    window.open(this.linkinfo.url);
  }
}
</script>

<style>
.link-card {
  position: relative;
  display: flex;
  cursor: pointer;
  height: 6rem;
  width: 12rem;
  align-items: center;
  justify-content: center;
  padding: 1rem;
  margin: 1rem 0.5rem;
  border-radius: 4px;
}

.link-card:hover {
  box-shadow: 4px 4px 8px 0px rgb(172, 169, 169);
}

.c-icon {
  margin-right: 1rem;
  width: 2rem;
  height: 2rem;
}

.c-title {
  overflow-wrap: break-word;
  overflow: hidden;
}
</style>