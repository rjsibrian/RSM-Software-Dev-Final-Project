<template>
  <div class="container">
    <TopBar class="topbar"></TopBar>
    <div class="router">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import TopBar from './components/TopBar.vue'

export default {
  name: 'App',
  components: {
    TopBar
  }
}
</script>

<style>
@import url('./styles.css');

html, body{
  background-color: #EFEFEF;
}

.container{
  display: flex;
  flex-direction: column;
  align-items: end;
  
}

.router{
  margin-top: 50px;
  width: 100%;
  height: 100%;
}

</style>