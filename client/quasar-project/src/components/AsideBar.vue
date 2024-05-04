<template>
<aside class="sidebar">
  <div class="links">
    <router-link to="/">
    <div class="item-container home-icon" :class="{ 'active-hover': $route.path === '/' }" >
      <img src="../assets/home-icon.png" alt="home icon" class="icons">
      <p class="item-link">Home</p>
    </div>
    </router-link>
    <router-link to="/reports">
    <div class="item-container report-icon" :class="{ 'active-hover': $route.path === '/reports' || $route.path === '/salesSummary' || $route.path === '/salesPerformance' }">
      <img src="../assets/report-icon.png" alt="report icon" class="icons">
      <p class="item-link">Reports</p>
    </div>
    </router-link>
  </div>
</aside>
</template>

<script>
export default {
  name: 'AsideBar',
  methods: {
    addHoverClass() {
      if (this.$route.path === '/') {
        this.$refs.item.classList.add('hover'); 
      }
    }
  }
};
</script>

<style scoped>
.sidebar {
  position: fixed;
  left: 0;
  top: 0; 
  bottom: 0; 
  background-color: #474454; 
  width: 16%;
  display: flex;
  flex-direction: column;
}

.links {
  display: flex;
  width: 83%;
  flex-direction: column;
  margin-left: auto;
  margin-right: auto;
  margin-top: 50px;
  gap: 10px;
}

.item-container{
  padding: 8px 25px 8px 25px;
  gap: 10px;
  width: auto;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: start;
  align-items: center;
}

.item-container .item-link{
  color: white;
  font-family: 'Outfit', sans-serif;
  font-size: 0.8rem;
  font-weight: 300;
  text-decoration: none;
  margin-top: 0;
  margin-bottom: 0;
  text-decoration-color: white;
}

.icons{
  width: 25px;
  height: 25px; 
}

.item-container:hover, .item-container.active-hover {
  background-color: #6F5CC3;
  border-radius: 5px;
  cursor: pointer;
}

.item-container:hover .item-link, .item-container.active-hover .item-link {
  color: white; 
  font-weight: bold;
}

.item-container:hover .icons path, .item-container.active-hover .icons path {
  fill:white;
}
</style>