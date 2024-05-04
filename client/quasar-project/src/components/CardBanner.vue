<template>
<div class="card">
    <div class="group1">
        <h3>Welcome to AdventureWorks reporting system</h3>
    </div>
    <img src="../assets/banner.svg" class="banner-img" alt="...">
</div>
</template>
  
<script>
  export default {
    name: 'CardBanner'
  };
</script>
  
<style scoped>
.card {
  width: 100%;
  height: 450px;
  display: flex;
  flex-direction: row;
  justify-content: start;
  align-items: start;
  flex-wrap: wrap;
  border-radius: 10px; 
  border: 1px solid transparent; 
  background-color: #ffffff;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1); 
  padding: 50px 50px 50px 50px;
}

.group1{
  height: auto;
  width: 50%;
  display: flex;
  flex-direction: row;
  justify-content: start;
  align-items: start;
  flex-wrap: wrap;
  border-radius: 10px; 
  background-color: #474454;
  border-top: 20px solid #6F5CC3; 
  padding: 15px 25px 15px 25px;
}

.group1 h3{
  font-family: 'Outfit';
  color: white;
  font-size: 1.7rem;
  font-weight: bold;
  margin: 0;
  padding: 0;
}

.banner-img{
  width: 50%;
  height: auto;
}

</style>