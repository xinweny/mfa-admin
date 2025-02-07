from fastapi import FastAPI

from app.api.routers import routers

app = FastAPI()

for router in routers:
    app.include_router(router)
