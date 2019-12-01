<template>
  <div class="hello">
    <!-- <div class="center input-box">
      <input type="text" />
    </div>-->
    <div class="tabs">
      <div v-for="(tab, index) in tabs" :key="index" class="group">
        <div class="tab-name">{{tab.name}}</div>
        <div class="tab-content">
          <div class="card-container" v-for="(link, index) in tab.links" :key="index">
            <Card :linkinfo="link"></Card>
          </div>
          <div class="card-container">
            <div class="link-card add-link" @click="add(tab.name)">+</div>
          </div>
        </div>
      </div>
      <Edit
        v-show="showedit"
        :action="edit.action"
        :tab="edit.tab"
        :link="edit.link"
        @result="endEdit"
      ></Edit>
    </div>

    <div class="diag"></div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue, Ref } from "vue-property-decorator";
import Card from "./LinkCard.vue";
import Edit from "./LinkEdit.vue";
import server from "../server";

@Component({
  components: { Card, Edit }
})
export default class HelloWorld extends Vue {
  @Prop() private msg!: string;
  private tabs: Tab[] = [];
  private showedit = false;
  private edit = {
    action: "add",
    tab: "",
    link: {}
  };

  private mounted() {
    this.refresh();
  }

  private async refresh() {
    this.tabs = await server.data();
  }

  private add(tab) {
    this.edit = {
      action: "add",
      tab: tab,
      link: {}
    };
    this.showedit = true;
  }

  private endEdit(val) {
    this.showedit = false;
    console.log(val);
    if (val !== "cancel") {
      this.refresh();
    }
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
  background-color: #f3f3f3;
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
  color: whitesmoke;
  text-shadow: 1px 3px 3px #497275, 0 0 0 #000;
}
</style>
