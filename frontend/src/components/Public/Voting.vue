<template>
<b-container class="h-100 p-0" fluid>
  <div class="prlxblock3 prlx pt-5" >
    <b-row class="w-100">
      <b-col lg=8 md=10 sm=12 offset-lg=2 offset-md=1 class="d-flex flex-row flex-wrap justify-content-around ">
        <b-card no-body v-for="vote in votes" :key="vote.id" class="vote-card m-3 pt-4"
                style="max-width: 20rem;"
                :img-src="vote.gift.image"
                img-alt="Image"
                img-top>
            <h4 slot="header">{{vote.gift.name}}</h4>
            <b-card-body class="pb-0">
              <p class="card-text">Стоимость {{vote.price}}</p>
            </b-card-body>
            <b-card-body>
              <b-progress class="mt-1" :max="(vote.votesAggree + vote.votesDisagree)" show-value :title="'Голосов <за> '+vote.votesAggree + '; Голосов <против> '+vote.votesDisagree">
                <b-progress-bar :value="vote.votesAggree" variant="success"></b-progress-bar>
                <b-progress-bar :value="vote.votesDisagree" variant="danger"></b-progress-bar>
              </b-progress>
            </b-card-body>
            <b-card-body v-if="isAuth">
              asd
            </b-card-body>
        </b-card>
      </b-col>
    </b-row>
  </div>
</b-container>
</template>

<script>
import {mapState, mapGetters} from 'vuex'

export default {
  computed: {
    ...mapState({
      votes: state => state.vote.votes
    }),
    ...mapGetters(['isAuth'])
  },
  async created () {
    this.$store.dispatch('reciveVotes')
  }
}
</script>

