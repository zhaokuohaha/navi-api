<template>
  <div class="link-card card" :style="customStyle" @click="openlink()">
    <img class="c-icon" :src="iconlink" alt srcset />
    <div class="c-title">{{linkinfo.title}}</div>
    <div class="link-option" v-show="edit">
      <div class="lo-edit" @click.stop="editlink">
        <i class="icono-gear"></i>
      </div>
      <div class="lo-delet" @click.stop="deletelink">
        <i class="icono-trash"></i>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Prop, Vue, Component, Provide } from "vue-property-decorator";
import * as model from "./model";

@Component
export default class LinkCard extends Vue {
  @Prop() private linkinfo!: Link;
  @Prop() private edit: boolean = false;

  get customStyle() {
    return {
      backgroundColor: this.linkinfo.bgcolor || "#fff"
    };
  }
  get iconlink() {
    return this.linkinfo.icon || "/favicon.ico";
  }

  editlink() {
    console.log("edit");
    this.$emit("edit");
  }

  deletelink() {
    console.log("delete");
    this.$emit("delete");
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

.link-option {
  position: absolute;
  background-color: rgba(0, 0, 0, 0.6);
  width: 100%;
  height: 100%;
}

.lo-edit {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.lo-delet {
  position: absolute;
  right: 0;
  top: 0;
  padding: 8px;
  background-color: tomato;
}
</style>