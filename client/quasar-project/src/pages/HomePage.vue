<template>
  <div class="main-home">
    <CardBanner></CardBanner>
  </div>
</template>

<script>
import CardBanner from 'src/components/CardBanner.vue';

export default {
  name: 'HomePage',
  components:{
    CardBanner
  }
}
</script>

<style scoped>

.main-home{
  padding: 20px;
  height: 100%;
}

</style>