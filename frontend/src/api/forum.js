import config from '@/packages/config'

export default {
  getTopics () {
    if (config.isLocalApp()) {
      return new Promise((resolve) => { resolve(data) })
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
