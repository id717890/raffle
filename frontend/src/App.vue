<template>
  <div id="app" style="height: 100%">
    <app-layout/>
  </div>
</template>

<script>
import layout from '@/components/Layout'

export default {
  components: {
    'app-layout': layout
  },
  name: 'app'
}
</script>

<style lang="scss">
@import './assets/scss/_app';

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  // color: #2c3e50;
  /* margin-top: 60px; */
}
</style>
