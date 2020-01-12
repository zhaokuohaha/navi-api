<template>
  <div class="card-edit">
    <div class="card edit-panel">
      <div class="title">编辑</div>
      <div class="form-item">
        <span>标题:</span>
        <input type="text" placeholder="标题" v-model="linkdata.title" />
      </div>
      <div class="form-item">
        <span>网址URL:</span>
        <input type="text" placeholder="网址URL" v-model="linkdata.url" />
      </div>
      <div class="form-item">
        <span>图标URL:</span>
        <input type="text" placeholder="图标URL" v-model="linkdata.icon" />
      </div>
      <div class="foot">
        <button v-if="action == model.action.add" @click="add()">添加</button> &nbsp;
        <button v-if="action == model.action.update" @click="update()">保存</button> &nbsp;
        <button class="pseudo" @click="cancel()">取消</button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Emit, Watch } from "vue-property-decorator";
import server from "../server";
import * as model from "./model";

@Component
export default class LinkEdit extends Vue {
  @Prop() action!: model.action;
  @Prop() tab!: number;
  @Prop() link!: Link;

  private linkdata: Link = this.link;
  private model = model;

  private async add() {
    if (!this.checkedit()) return;
    await server.addLink(this.tab, this.linkdata);
    this.$emit("result", model.action.add);
  }

  private async update() {
    if (!this.checkedit()) return;
    await server.changeLink(this.linkdata);
    this.$emit("result", model.action.update);
  }

  private checkedit() {
    if (!this.tab) {
      alert("系统错误： Tab 传值失败");
      return false;
    }

    if (!this.linkdata || !this.linkdata.title || !this.linkdata.url) {
      alert("请填写网址和标题");
      return false;
    }

    if (this.linkdata.title.length > 12) {
      alert("标题不能长于12个字");
      return false;
    }

    return true;
  }

  private cancel() {
    this.linkdata = JSON.parse(JSON.stringify(this.link));
    this.$emit("result", model.action.cancel);
  }

  @Watch("link")
  private linkChange(val: Link) {
    this.linkdata = JSON.parse(JSON.stringify(val));
  }
}
</script>

<style scoped>
.card-edit {
  position: fixed;
  width: 100%;
  height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 100;
  background-color: rgba(0, 0, 0, 0.1);
  top: 0;
  left: 0;
}

.edit-panel {
  width: 50%;
  padding: 2rem 2rem 1rem 2rem;
  box-shadow: 4px 4px 8px 0px rgb(172, 169, 169);
}

.title {
  border-bottom: solid 1px #777;
  margin-bottom: 1rem;
  font-weight: bold;
}

.form-item {
  display: flex;
  margin: 1rem 0;
  align-items: center;
}

.form-item span {
  width: 6rem;
  text-align: right;
  margin-right: 0.5rem;
}

div.foot {
  text-align: right;
}
</style>