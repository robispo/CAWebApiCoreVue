<template>
  <div id="app" class="container-fluid">
    <app-header />
    <router-view></router-view>
  </div>
</template>

<script>

  import Header from './components/share/header.vue';

  export default {
    name: 'app',
    components: {
      appHeader: Header
    }
  }
</script>

<style>
  body{
    padding-top: 5rem;
  }      
</style>