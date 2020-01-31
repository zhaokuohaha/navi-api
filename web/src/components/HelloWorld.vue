<template>
  <div class="hello">
    <!-- <div class="center input-box">
      <input type="text" />
    </div>-->
    <div class="menu-wrapper">
      <i class="icon-btn" :class="getSettingIcon()" @click="tryEdit()"></i>
    </div>

    <div v-if="!canedit &&(!tabs || tabs.length <= 0)" style="margin: 100px auto; width: 100px">
      <img
        class="pointer"
        width="100"
        height="100"
        src="../assets/edit.svg"
        alt
        srcset
        @click="tryEdit()"
      />
    </div>
    <div v-else class="tabs">
      <div v-for="(tab, index) in tabs" :key="index" class="group">
        <div class="tab-name">{{tab.name}}</div>
        <div class="tab-content">
          <div class="card-container" v-for="(link, index) in tab.links" :key="index">
            <Card
              :linkinfo="link"
              :edit="canedit"
              @edit="editlink(link, tab.name)"
              @delete="deletelink(link)"
            ></Card>
          </div>
          <div class="card-container" v-show="canedit">
            <div class="link-card add-link" @click="addlink(tab.id)">+</div>
          </div>
        </div>
      </div>
      <Edit
        v-show="showedit"
        :action="editdata.action"
        :tab="editdata.tab"
        :link="editdata.link"
        @result="endEdit"
      ></Edit>

      <div class="group" v-show="canedit">
        <div class="add-tab" @click="$modal.show('addtab')">+</div>
      </div>
    </div>

    <div class="diag"></div>
    <navi-modal name="auth" :height="200">
      <div class="pwd-wrapper">
        <label for="pwd">密码:</label>
        <input type="password" name="pwd" id="pwd" v-model="pwd" />
        <button @click="auth">确定</button>
      </div>
    </navi-modal>

    <navi-modal name="addtab" :height="200">
      <div class="pwd-wrapper">
        名称:
        <input type="text" v-model="newTabName" />
        <button @click="addtab">确定</button>
      </div>
    </navi-modal>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue, Ref } from "vue-property-decorator";
import Card from "./LinkCard.vue";
import Edit from "./LinkEdit.vue";
import server from "../server";
import * as model from "./model";

@Component({
  components: { Card, Edit }
})
export default class HelloWorld extends Vue {
  @Prop() private msg!: string;
  private tabs: Tab[] = [];
  private showedit = false;
  private canedit = false;
  private pwd = "";
  private newTabName = "";

  private editdata = {
    action: model.action.default,
    tab: -1,
    link: {}
  };

  private mounted() {
    this.refresh();
  }

  private async refresh() {
    let u = this.$route.params.user;
    if (!u) {
      u = "me";
      this.$router.push("/me");
    }
    this.tabs = await server.data(u);
  }

  private addlink(tab: number) {
    this.editdata = {
      action: model.action.add,
      tab: tab,
      link: {}
    };
    this.showedit = true;
  }

  private async addtab() {
    if (!this.newTabName) alert("请输入分类名称");
    if (await server.addTab(this.newTabName)) this.refresh();
    else alert("添加失败");
    this.$modal.hide("addtab");
  }

  private editlink(link: Link) {
    console.log("编辑", link);
    this.editdata = {
      action: model.action.update,
      tab: link.tabid,
      link: link
    };
    this.showedit = true;
  }

  private async deletelink(link: Link) {
    let result = await server.deletelink(link.id);
    if (result) {
      console.log("移除" + link.title);
      this.refresh();
    }
  }

  private endEdit(val: model.action) {
    this.showedit = false;
    console.log(val);
    if (val !== model.action.cancel) {
      this.refresh();
    }
  }

  private tryEdit() {
    if (!this.canedit) this.$modal.show("auth");
    else this.canedit = !this.canedit;
  }

  private async auth() {
    console.log(this.$route);
    let user = this.$route.path.split("/").pop();
    let isauth = user && (await server.auth(user, this.pwd));
    if (isauth) {
      this.canedit = !this.canedit;
    } else {
      alert("密码不正确");
    }

    this.$modal.hide("auth");
  }

  private getSettingIcon() {
    return this.canedit ? ["icono-check", "icon-success"] : "icono-sliders";
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.group {
  padding: 1rem 1rem;
  margin: 2rem;
}

.tab-name {
  border-bottom: solid 1.5px rgb(197, 197, 197);
  padding-bottom: 0.5rem;
  font-weight: bold;
  color: #78b2b6;
}

.tab-content {
  background-color: #f5f5f5;
  display: flex;
  align-items: center;
  flex-wrap: wrap;
}

.card-container {
  display: inline-block;
}

.input-box {
  width: 60%;
  margin: auto;
}

.add-link {
  font-size: 5rem;
  border-radius: 4px;
  background-color: #78b2b6;
  font-family: Helvetica, Arial, sans-serif;
  font-weight: bold;
  color: #f5f5f5;
  text-shadow: 1px 3px 3px #497275, 0 0 0 #000;
}

.add-tab {
  font-size: 5rem;
  border-radius: 4px;
  color: #78b2b6;
  font-family: Helvetica, Arial, sans-serif;
  font-weight: bold;
  cursor: pointer;
  background-color: #f5f5f5;
  text-align: center;
  text-shadow: 1px 3px 3px #497275;
}

.menu-wrapper {
  position: absolute;
  top: 8px;
  right: 8px;
}

.pwd-wrapper {
  padding: 8px 16px;
  height: 30px;
}

.flex {
  display: flex;
}

.icon-success {
  color: lightgreen;
  zoom: 1.8;
}
</style>
