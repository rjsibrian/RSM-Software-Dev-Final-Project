<template>
  <div class="main-container">
    <h3>Sales Summary</h3>
    <SummaryTable class="table"></SummaryTable>
  </div>
</template>

<script>
import SummaryTable from '../components/SummaryTable.vue';
export default {
name: 'SalesSummaryPage',
components: {
  SummaryTable
}
};
</script>

<style scoped >

.main-container{
  display: flex;
  flex-direction: column;
  gap: 0px;
  padding: 0px 20px 20px 20px;
}

h3{
  font-family: 'Outfit';
  background-color: #474454;
  font-weight: 500;
  color: #ffffff;
  font-size: 1.1rem;
  width: 100%;
  padding-left: 20px;
  border-left: 10px solid #6F5CC3; 
  border-radius: 5px; 
  text-align: start;
}

.table{
  padding: 0;
  margin:0;
}

</style>
