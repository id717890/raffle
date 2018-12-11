<template>
<b-container class="h-100 p-0" fluid>
  <div class="prlxblock3 prlx pt-5" >
    <b-row class="w-100">
      <b-col lg=8 md=10 sm=12 offset-lg=2 offset-md=1>
        <b-jumbotron bg-variant="secondary" text-variant="white" class="mt-3 pb-4" border-variant="dark">
          <template slot="header">
            Выбирай и голосуй
          </template>
          <template slot="lead">
            Вибирай призы, которые тебе по душе, голосуй за них 
          </template>
          <hr class="my-4">
          <p>* Зарегистрируйся чтобы голосовать</p>
          <p class="p-0 m-0">* Голосуй за несколько подарков</p>
        </b-jumbotron>
      </b-col>
    </b-row>
    <b-row class="w-100">
      <b-col lg=8 md=10 sm=12 offset-lg=2 offset-md=1 class="d-flex flex-row flex-wrap justify-content-around ">
        <b-card no-body v-for="vote in votes" :key="vote.id" class="vote-card m-3 pt-4"
                style="max-width: 20rem;"
                :img-src="vote.giftImage === null ? '/static/images/gifts/'+ vote.giftImageLocal  : vote.giftImage"
                img-alt="Image"
                img-top>
            <h4 slot="header">{{vote.giftName}}</h4>
            <b-card-body class="pb-0">
              <p class="card-text">Стоимость {{vote.price}}</p>
            </b-card-body>
            <b-card-body>
              <b-progress class="mt-1" :max="(vote.votesAgree + vote.votesDisagree)" show-value :title="'Голосов <за> '+ vote.votesAgree + '; Голосов <против> '+ vote.votesDisagree">
                <b-progress-bar :value="vote.votesAgree" variant="success"></b-progress-bar>
                <b-progress-bar :value="vote.votesDisagree" variant="danger"></b-progress-bar>
              </b-progress>
            </b-card-body>
            <b-card-body v-if="isAuth" class="m-0 pt-0">
              <div v-if="vote.userVote == null && !test(vote.id)" class="d-flex justify-content-center align-content-stregth" style="flex: 1 1 auto">
                <button @click="addVote(vote.id, true)" class="btn btn-success mr-1" style="flex: 1 1 50%">ЗА</button>
                <button @click="addVote(vote.id, false)" class="btn btn-danger ml-1" style="flex: 1 1 50%">Против</button>
              </div>
              <div v-else class="d-flex justify-content-center align-content-stregth" style="flex: 1 1 auto">
                <p class="w-100 m-0 text-success" style="font-weight: bolder;" v-if="vote.userVote === true">Вы проголосовали "ЗА"</p>
                <p class="w-100 m-0 text-danger" style="font-weight: bolder;" v-if="vote.userVote === false">Вы проголосовали "ПРОТИВ"</p>
              </div>
              <div class="loader" v-if="test(vote.id)"></div>
            </b-card-body>
        </b-card>
      </b-col>
    </b-row>
  </div>
</b-container>
</template>

<script>
import {mapState, mapGetters, mapActions} from 'vuex'

export default {
  computed: {
    ...mapState({
      votes: state => state.vote.votes
    }),
    ...mapGetters(['isAuth', 'isVoteBusy'])
  },
  async created () {
    this.$store.dispatch('reciveVotes')
  },
  methods: {
    ...mapActions(['giveVote']),
    addVote (voteId, value) {
      this.giveVote({id: voteId, value: value})
    },
    test (vote) {
      // console.log(this.$store.getters['isVoteBusy'](vote))
      return this.$store.getters['isVoteBusy'](vote)
    }
  }
}
</script>

