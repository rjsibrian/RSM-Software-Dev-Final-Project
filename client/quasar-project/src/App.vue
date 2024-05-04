<template>
  <AsideBar></AsideBar>
  <div class="container">
    <TopBar class="topbar"></TopBar>
    <div class="router">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import AsideBar from './components/AsideBar.vue'
import TopBar from './components/TopBar.vue'

export default {
  name: 'App',
  components: {
    AsideBar,
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
  margin-left: 16%;
  
}

.router{
  margin-top: 50px;
  width: 100%;
  height: 100%;
}

</style>