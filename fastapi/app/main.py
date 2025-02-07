from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware

from app.config import get_settings
from app.api.routers import routers

app = FastAPI(
    title='MFA Membership API',
    description='A FastAPI API for managing members and memberships of the Mississauga Friendship Association'
)

app.add_middleware(
    CORSMiddleware,
    allow_origins=[get_settings().api_url],
    allow_methods=['GET', 'POST', 'PUT', 'DELETE', 'OPTIONS'],
    allow_headers=['*'],
    allow_credentials=True
)

for router in routers:
    app.include_router(router)
