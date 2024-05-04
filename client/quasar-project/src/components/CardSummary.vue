<template>
<div class="card">
  <img src="../assets/sSummary.svg" class="card-img" alt="...">
  <h5 class="card-title">Sales Summary</h5>
</div>
</template>
  
<script>
  export default {
    name: 'CardSummary'
  };
</script>
  
<style scoped>
.card {
  width: 400px;
  height: 300px;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  border-radius: 10px; 
  border: 1px solid transparent; 
  background-color: #ffffff;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1); 
  padding-bottom: 0;
}
img{
  width: 300px;
  height: auto;
}
h5{
  font-family: 'Outfit';
  font-weight: bold;
  color: #6F5CC3;
  margin: 0;
  font-size: 1.3rem;
}
</style>
  