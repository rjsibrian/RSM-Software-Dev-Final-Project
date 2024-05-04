<template>
  <div class="main">
    <h3>Reports available</h3>
    <div class="cards">
      <router-link to="/salesSummary" class="card-link"><CardSummary></CardSummary></router-link>
      <router-link to="/salesPerformance" class="card-link"><CardPerformance></CardPerformance></router-link>
    </div>
  </div>
</template>

<script>
import CardSummary from '../components/CardSummary.vue';
import CardPerformance from 'src/components/CardPerformance.vue';

export default {
  name: 'ReportsPage',
  components:{
    CardSummary,
    CardPerformance
  },
  data() {
    return {
    };
  },
}
</script>

<style scoped>

.cards{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    gap: 30px;
    justify-content: center;
    padding-bottom: 20px;
  }

  .main{
    text-align: center;
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    justify-content: space-evenly;
    align-items: center;
    gap: 20px;
    padding: 0px 20px 20px 20px;
  }

  .main h3{
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

  .card-link {
  cursor: pointer; 
  transition: transform 0.3s; 
  text-decoration: none;
  }

  .card-link:hover {
    transform: scale(1.02); 
  }

</style>
