<template>
  <div id="app">
    <div class="center">
      <img alt="logo" src="./assets/logo.png" class="logo" />
    </div>
    <HelloWorld :msg="'World'" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import HelloWorld from "./components/HelloWorld.vue";

@Component({
  components: {
    HelloWorld
  }
})
export default class App extends Vue {}
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
</style>
