import * as types from '../mutation-types'
import context from '@/api/info'
import config from '@/packages/config'

const state = {
  info: {}
}

// actions
const actions = {
  async reciveInfo ({commit, dispatch}) {
    return new Promise((resolve, reject) => {
      context.getInfo().then((x) => {
        if (config.isLocalApp()) {
          commit(types.RECIEVE_INFO, x)
          commit(types.SET_LOADING, false)
          resolve()
        } else {
          if (x.status === 200) {
            commit(types.RECIEVE_INFO, x.data)
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
  [types.RECIEVE_INFO] (state, payload) {
    state.info = payload
  }
}

// getters
const getters = {
}

export default {
  state,
  getters,
  actions,
  mutations
}
