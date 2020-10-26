import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";
import sa from "../services/SweetAlerts.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    queryUserKeeps: [],
    keeps: [],
    activeKeep: {},
    vaults: []
  },
  mutations: {

    //#region Profile
    setProfile(state, profile) {
      state.profile = profile;
    },
    //#endregion

    //#region Keeps
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    },
    setQueryUserKeeps(state, queryKeeps){
      state.queryUserKeeps = queryKeeps
    }

    //#endregion

    //#region Vaults


    //#endregion

  },
  actions: {


    //#region Profile

    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    //#endregion

    //#region Keeps
    async getAllKeeps({ commit, dispatch }) {
      let res = await api.get("keeps")
      commit("setKeeps", res.data)
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      await api.delete("keeps/" + keepId)
      dispatch("getAllKeeps")
    },
    async createKeep({ commit, dispatch }, keepData) {
      await api.post("keeps", keepData)
      dispatch("getAllKeeps")
    },
    activeKeep({ commit, dispatch }, activeKeep) {
      commit("setActiveKeep", activeKeep)
      sa.viewActiveKeep(activeKeep.name, activeKeep.description, activeKeep.img)
    },
    async getKeepsByProfile({commit,dispatch}, profId){
      try {
        let res = await api.get("profiles/"+profId+"/keeps")
        commit("setQueryUserKeeps", res.data)
      } catch (error) {
        console.error(error);
      }
    }

    //#endregion

    //#region Vaults


    //#endregion


  },
});
