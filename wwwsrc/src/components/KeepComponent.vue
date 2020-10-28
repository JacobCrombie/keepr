<template>
  <div class="keep-component col-3 my-2">
    <div class="card">
      <img
        class="card-img-top"
        :src="keepProp.img"
        data-toggle="modal"
        data-target="#keep-modal"
        @click="setActiveKeep"
      />
      <div class="card-body">
        <h4 class="card-title">{{ keepProp.name }}</h4>
        <img class="rounded-circle" :src="keepProp.creator.picture" alt="" />
      </div>
    </div>

    <div class="modal fade" id="keep-modal" tabindex="-1" role="dialog">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content card">
          <div class="modal-header">
            <h5 class="modal-title">{{ activeKeep.name }}</h5>
            <h5>{{ activeKeep.creator.name }}</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="card-body d-flex flex-row">
            <img class="card-img-left" :src="activeKeep.img" alt="" />
            <div class="modal-body">
              <h5>
                {{ activeKeep.description }}
              </h5>
              <img
                class="rounded-circle"
                :src="activeKeep.creator.picture"
                alt=""
                @click="profilePush"
                data-dismiss="modal"
              />
            </div>
          </div>
          <div class="modal-footer d-flex justify-content-between">
            <p>Views:{{ activeKeep.views }}</p>
            <p>Kept:{{ activeKeep.keeps }}</p>
            <button
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
            >
              Close
            </button>
            <button type="button" class="btn btn-primary" @click="addKeep">
              Save changes
            </button>
            <div class="form-group">
              <label for=""></label>
              <select class="form-control" v-model="vaultSelect">
                <option v-for="v in myVaults" :key="v.id" :value="v.id">
                  {{ v.name }}
                </option>
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import router from "../router/index.js";
export default {
  name: "keep-component",
  props: ["keepProp"],
  data() {
    return {
      vaultSelect: "",
    };
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    myVaults() {
      return this.$store.state.myVaults;
    },
  },
  methods: {
    setActiveKeep() {
      let count = this.keepProp.views;
      count++;
      let keepEdit = {
        views: count,
        id: this.keepProp.id,
        creatorId: this.keepProp.creator.id,
      };
      this.$store.dispatch("editKeep", keepEdit);
      this.$store.dispatch("activeKeep", this.keepProp);
    },
    addKeep() {
      let addKeepData = {
        keepId: this.activeKeep.id,
        vaultId: this.vaultSelect,
      };
      this.$store.dispatch("addKeepToVault", addKeepData);
      let count = this.activeKeep.keeps;
      debugger
      count ++;
      let keepEdit = {
        keeps: count,
        id: this.activeKeep.id,
        creatorId: this.activeKeep.creator.id
      }
      this.$store.dispatch("editKeep", keepEdit)
      this.vaultSelect = "";
    },
    profilePush() {
      this.$store.dispatch("getProfileById", this.keepProp.creator.id)
    },
  },
  components: { router },
};
</script>


<style scoped>
.modal-dialog {
  max-width: 50vw;
}
</style>