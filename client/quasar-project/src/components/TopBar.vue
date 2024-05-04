<template>
    <div class="topbar">
      <p class="title">AdventureWorks</p>
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
  width: 84%;
  right: 0;
  position: fixed;
  height: 50px;
  background-color: #6F5CC3; 
  text-align: end;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: start;
}

.topbar p{
  margin-top: 0;
  margin-bottom: 0;
  margin-left: 15px;
  color: #ffffff;
  font-size: 1rem;
  font-family: 'Outfit';
  font-weight: bold;
}
</style>
