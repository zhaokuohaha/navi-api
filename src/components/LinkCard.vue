<template>
  <div class="card" @click="openlink()">
    <div class="c-icon">
      <img :src="linkinfo.icon" alt srcset />
    </div>
    <div class="c-title">{{linkinfo.title}}</div>
  </div>
</template>

<script lang="ts">
import { Prop, Vue, Component } from "vue-property-decorator";

@Component
export default class LinkCard extends Vue {
  @Prop() private linkinfo!: Link;

  openlink() {
    console.log(this.linkinfo.url);
    window.open(this.linkinfo.url);
  }
}
</script>

<style scoped>
.card {
  position: relative;
  display: inline-flex;
  cursor: pointer;
  height: 6rem;
  min-width: 12rem;
  align-items: flex-end;
  justify-content: center;
  padding: 1rem;
  margin: 1rem;
}

.card:hover {
  box-shadow: 4px 4px 8px 0px rgb(172, 169, 169);
}

.c-icon {
  margin-right: 1rem;
}
</style>