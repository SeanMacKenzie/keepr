<template>
  <div id="app">
    <error></error>
    <router-view/>
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
    }
  }
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>