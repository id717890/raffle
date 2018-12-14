<template>
  <b-container  class="p-0 mt-3 pt-5">
    <b-row>
      <b-col lg=3 md=4 sm=12>
        <b-list-group>
          <b-list-group-item v-for="topic in topics" :key="topic.id" @click="setCurrentTopic(topic)"
            class="d-flex justify-content-between align-items-center" 
            :class="currentTopic.id == topic.id ? 'active' : ''">
              {{topic.caption}}
            <b-badge variant="secondary" pill>{{topic.messages.length}}</b-badge>
          </b-list-group-item>
        </b-list-group>
      </b-col>
      <b-col lg=9 md=8 sm=12>
        <b-card class="p-2 mb-2" v-for="message in currentTopic.messages" :key="message.id">
          <p class="text-left">{{message.date}}</p>
          {{message.text}}
        </b-card>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import {mapGetters, mapActions, mapState} from 'vuex'

export default {
  data () {
    return {
    }
  },
  computed: {
    test () {
      console.log(11)
      return 0
    },
    ...mapGetters(['loading']),
    ...mapState({
      topics: state => state.forum.topics,
      currentTopic: state => state.forum.currentTopic
    })
  },
  created () {
    this.reciveTopics()
  },
  methods: {
    ...mapActions(['reciveTopics', 'setTopic']),
    setCurrentTopic (topic) {
      this.setTopic(topic)
    }
  }
}
</script>

