import * as types from '../mutation-types'
import context from '../../api/vote'
import config from '@/packages/config'
import Vue from 'vue'

const state = {
  votes: [],
  votesBusy: []
}

// actions
const actions = {
  async giveVote ({commit, dispatch}, payload) {
    let credential = Vue.auth.getCredentials()
    if (credential != null) {
      commit(types.ADD_VOTE_TO_BUSY, payload.id)
      let voteUser = {id: payload.id, userId: credential.id, value: payload.value}
      context.giveVote(voteUser).then(x => {
        if (x.status === 200) {
          commit(types.ADD_VOTE, voteUser)
          commit(types.REMOVE_VOTE_FROM_BUSY, payload.id)
        } else {
          dispatch('setErrors', x.response.data)
          commit(types.REMOVE_VOTE_FROM_BUSY, payload.id)
        }
      })
    }
  },
  async reciveVotes ({commit, dispatch}) {
    context.getVotes(Vue.auth.getUser()).then((x) => {
      if (config.isLocalApp()) {
        commit(types.RECIEVE_VOTES, x)
        commit(types.SET_LOADING, false)
      } else {
        if (x.status === 200) {
          commit(types.RECIEVE_VOTES, x.data)
        } else {
          dispatch('setErrors', x.response.data)
        }
      }
    }).catch(x => {
      dispatch('setErrors', x.response.data)
    })
  }
}

// mutations
const mutations = {
  [types.ADD_VOTE] (state, payload) {
    let findVote = state.votes.find(x => x.id === payload.id)
    if (findVote !== null) {
      if (payload.value === true) {
        findVote.votesAgree += 1
        findVote.userVote = true
      } else {
        findVote.votesDisagree += 1
        findVote.userVote = false
      }
    }
  },
  [types.RECIEVE_VOTES] (state, payload) {
    state.votes = payload
  },
  [types.ADD_VOTE_TO_BUSY] (state, payload) {
    state.votesBusy.push(payload)
  },
  [types.REMOVE_VOTE_FROM_BUSY] (state, payload) {
    let votePosition = state.votesBusy.indexOf(payload)
    if (votePosition !== -1) {
      state.votesBusy.splice(votePosition, 1)
    }
  }
}

// getters
const getters = {
  isVoteBusy: state => voteId => {
    let vote = state.votesBusy.find(x => x === voteId)
    return vote !== undefined
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
