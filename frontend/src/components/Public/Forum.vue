<template>
  <b-container fluid class="p-0">
    <b-row class="mt-3">
      <b-col lg=3 md=4 sm=12>
        <b-list-group>
          <b-list-group-item v-for="topic in topics" :key="topic.id" @click="setCurrentTopic(topic)"
            class="d-flex justify-content-between align-items-center" 
            :class="currentTopic.id == topic.id ? 'active' : ''">
            {{topic.caption}}
            <b-badge variant="secondary" pill>{{topic.messages.length}}</b-badge>
          </b-list-group-item>

          <!-- <b-list-group-item class="d-flex active justify-content-between align-items-center">
            Cras justo odio
            <b-badge variant="primary" pill>14</b-badge>
          </b-list-group-item>
          <b-list-group-item class="d-flex justify-content-between align-items-center">
            Dapibus ac facilisis in
            <b-badge variant="primary" pill>2</b-badge>
          </b-list-group-item>
          <b-list-group-item class="d-flex justify-content-between align-items-center">
            Morbi leo risus
            <b-badge variant="primary" pill>1</b-badge>
          </b-list-group-item> -->
        </b-list-group>
      </b-col>
      <b-col lg=9 md=8 sm=12>
        <b-card class="p-2 m-2" v-for="message in currentTopic.messages" :key="message.id">
          <p class="text-left">{{message.date}}</p>
          {{message.text}}
        </b-card>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
export default {
  data () {
    return {
      topics: data,
      currentTopic: null
    }
  },
  async created () {
    if (this.topics.length > 0) this.currentTopic = this.topics[0]
  },
  methods: {
    setCurrentTopic (topic) {
      this.currentTopic = topic
    }
  }
}

const data = [
  {
    id: 1,
    caption: 'Розыгрыши',
    messages: [
      {
        id: 1,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      },
      {
        id: 2,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      },
      {
        id: 3,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      },
      {
        id: 4,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      },
      {
        id: 5,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      }
    ]
  },
  {
    id: 2,
    caption: 'Пожелания',
    messages: [
      {
        id: 1,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      }
    ]
  },
  {
    id: 3,
    caption: 'Пожелания',
    messages: [
      {
        id: 1,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      },
      {
        id: 2,
        date: new Date(),
        text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Quaerat necessitatibus architecto assumenda corrupti dolorum molestias nemo, eum laboriosam. Quis sequi distinctio id quaerat atque! Voluptatem similique ratione autem earum voluptatibus?'
      }
    ]
  }
]
</script>

