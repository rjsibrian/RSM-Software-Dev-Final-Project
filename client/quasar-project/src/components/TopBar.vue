<template>
    <div class="topbar">
      <router-link to="/" class="card-link"><p class="title">AdventureWorks</p></router-link>
    </div>
</template>

<script>
export default {
  name: 'TopBar',
  components: {
  }
};
</script>

<style scoped >

.topbar {
  width: 100%;
  height: 50px;
  background-color: #6F5CC3; 
  text-align: end;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: start;
  position: fixed;
  top: 0;
  left: 0;
  z-index: 999; /* Asegúrate de que la barra superior esté por encima de otros elementos */
}

.topbar p{
  margin-top: 0;
  margin-bottom: 0;
  margin-left: 20px;
  color: #ffffff;
  font-size: 1rem;
  font-family: 'Outfit';
  font-weight: bold;
}

.topbar .card-link{
  text-decoration: none;
}

.topbar .card-link:active{
  text-decoration: none;
}

</style>
