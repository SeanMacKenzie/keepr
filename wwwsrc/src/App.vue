<template>
  <div id="app">
    <!-- <error></error> -->
    <router-view></router-view>
  </div>
</template>

<script>
  import Error from './components/Error'
  export default {
    name: 'app',
    data() {
      return {

      }
    },
    mounted() {
      //dispatch authenticate
      this.$store.dispatch('authenticate')
    },
    components: {
      Error
    }
  }
</script>

<style>
  @import url('https://fonts.googleapis.com/css?family=Anton|Audiowide|Fjalla+One|Karla|Kavivanar|Source+Code+Pro');
  #app {

    
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    
    
    background-image: url("https://www.transparenttextures.com/patterns/dust.png");
    background-color: #0f0003;
    min-height: 100vh;
    font-family: 'Karla', sans-serif;
    color: #8d9229;
  }
</style>