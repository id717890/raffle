<template>
  <b-container>
    <b-row class="pt-5 justify-content-center" >
      <b-col xl=5 lg=7 md=9 sm=12>
        <b-jumbotron bg-variant="success" text-variant="white">
          <!-- <template slot="header">
            Bootstrap Vue
          </template> -->
          <div slot="lead" v-for="(message, index) in this.getMessages" :key="index">{{message}}</div>
          <hr class="my-4">
          <b-btn variant="secondary" to="/">Home page</b-btn>
          <b-btn variant="dark" to="/signin">Log In</b-btn>
        </b-jumbotron>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import {mapGetters} from 'vuex'

export default {
  computed: {
    ...mapGetters(['getMessages'])
  }
}
</script>

