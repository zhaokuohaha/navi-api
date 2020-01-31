<template>
  <div id="app">
    <div class="center">
      <span style="width:1px" @mouseenter="toggleGetOne" @mouseleave="toggleGetOne">
        <img
          v-show="showGetOne"
          class="pointer logo"
          @click="$modal.show('adduser')"
          src="./assets/getone.jpg"
          alt="整一个"
        />
        <img v-show="!showGetOne" alt="logo" src="./assets/logo.png" class="logo pointer" />
      </span>
    </div>
    <HelloWorld />
    <navi-modal name="adduser">
      <div class="navi-modal-content">
        路径： (例如: {{$route.path.split('/').pop()}})
        <input type="text" v-model="user.name" />
        密码：(编辑需要校验)
        <input type="text" v-model="user.pwd" />

        <div class="navi-modal-footer">
          <button @click="addUser()">确定</button>
          <button class="pseudo" @click="$modal.hide('adduser')">取消</button>
        </div>
      </div>
    </navi-modal>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "./components/HelloWorld.vue";
import * as model from "./components/model";
import server from "./server";

@Component({
  components: {
    HelloWorld
  }
})
export default class App extends Vue {
  private showGetOne = false;
  private user: model.User = new model.User();
  private mounted() {}

  private toggleGetOne() {
    this.showGetOne = !this.showGetOne;
  }

  private async addUser() {
    if (!this.checkUser()) return;
    var res = await server.addUser(this.user);
    if (res) {
      this.$modal.hide("adduser");
      this.$router.push(`/${this.user.name}`);
    }
  }

  private checkUser() {
    if (!this.user || !this.user.name || !this.user.pwd) {
      alert("请填写路径和密码");
      return false;
    }
    if (this.user.name.indexOf("/") >= 0) {
      alert("路径名不能包含‘/’字符");
      return false;
    }
    return true;
  }
}
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}

.center {
  text-align: center;
}

.logo {
  width: 8rem;
  height: 8rem;
  border-radius: 8rem;
}

.icon-btn {
  cursor: pointer;
}

.pointer {
  cursor: pointer;
}

.navi-modal-content {
  padding: 12px 18px;
}

.navi-modal-footer {
  position: absolute;
  right: 12px;
  bottom: 12px;
}

.img-icon {
  width: 2rem;
  height: 2rem;
}
</style>
