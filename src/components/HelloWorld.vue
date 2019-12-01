<template>
  <div class="hello">
    <div class="center input-box">
      <input type="text" />
    </div>
    <div class="tabs">
      <div v-for="(tab, index) in tabs" :key="index" class="group">
        <div class="tabname">{{tab.name}}</div>
        <div class="tabcontent">
          <Card v-for="(link, index) in tab.links" :key="index" :linkinfo="link"></Card>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue, Ref } from "vue-property-decorator";
import Card from "./LinkCard.vue";
import Tabs from "../data";

@Component({
  components: { Card }
})
export default class HelloWorld extends Vue {
  @Prop() private msg!: string;
  private tabs = Tabs;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.group {
  padding: 1rem 1rem;
  margin: 2rem;
}

.tabname {
  border-bottom: solid 1.5px rgb(197, 197, 197);
  padding-bottom: 0.5rem;
  font-weight: bold;
  color: #78b2b6;
}

.tabcontent {
  background-color: #f3f3f3;
}

.card-wrapper {
  display: inline-block;
  margin: 0 1rem 1rem 0;
}

.input-box {
  width: 60%;
  margin: auto;
}
</style>
