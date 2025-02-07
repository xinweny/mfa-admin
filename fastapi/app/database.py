from fastapi import Depends
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, declarative_base

from app.config import get_settings

engine = create_engine(get_settings().db_url)

SessionLocal = sessionmaker(
    bind=engine,
    autocommit=False,
    autoflush=False,
)

def get_session():
    with SessionLocal(engine) as session:
        yield session
  
SessionDep = Depends(get_session)

Base = declarative_base()

def get_db():
    db = SessionLocal()
    
    try:
        yield db
    finally:
        db.close()
        
DbDep = Depends(get_db)