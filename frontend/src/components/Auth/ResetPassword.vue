<template>
  <h1>RESET</h1>
</template>

<script>
export default {
  created () {
    console.log(this.$route.query.id) // outputs 'yay'
    console.log(this.$route.query.code) // outputs 'yay'
  }
}
</script>
