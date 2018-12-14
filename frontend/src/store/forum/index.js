import * as types from '../mutation-types'
import context from '@/api/forum'
import config from '@/packages/config'

const state = {
  topics: [],
  currentTopic: null
}

// actions
const actions = {
  setTopic ({commit}, payload) {
    commit(types.SET_CURRENT_TOPIC, payload)
  },
  reciveTopics ({commit, dispatch}) {
    return new Promise((resolve, reject) => {
      context.getTopics().then((x) => {
        if (config.isLocalApp()) {
          commit(types.RECIEVE_TOPICS, x)
          commit(types.SET_LOADING, false)
          resolve()
        } else {
          if (x.status === 200) {
            commit(types.RECIEVE_TOPICS, x.data)
            resolve()
          } else {
            dispatch('setErrors', x.response.data)
            reject(x.response.data)
          }
        }
      }).catch(x => {
        reject(x.response.data)
      })
    })
  }
}

// mutations
const mutations = {
  [types.RECIEVE_TOPICS] (state, payload) {
    state.topics = payload
    if (state.topics.length > 0) state.currentTopic = state.topics[0]
  },
  [types.SET_CURRENT_TOPIC] (state, payload) {
    state.currentTopic = payload
  }
}

// getters
const getters = {
  getTopics: state => state.topics,
  getCurrentTopic (state) {
    return state.currentTopic
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
