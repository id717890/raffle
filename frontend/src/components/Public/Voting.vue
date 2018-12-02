<template>
<b-container class="h-100 p-0" fluid>
  <div class="prlxblock3 prlx d-flex flex-row justify-content-around align-items-center" >
    <b-card v-for="vote in votes" :key="vote.id">
      {{vote.gift.name}}
    </b-card>
  </div>
</b-container>
</template>

<script>
import {mapState} from 'vuex'

export default {
  computed: {
    ...mapState({
      votes: state => state.vote.votes
    })
  },
  async created () {
    this.$store.dispatch('reciveVotes')
  }
}
</script>

